import os

import parse

def butcher_svg_file(file_path, out_path, stations):
    longestName = max([len(i) for i in stations.keys()])+1 # add one to avoid writing mid-"use" object issues
    buffer = ""
    lastMatchedName = None
    lastMatchedID = None
    lastMatchedIndex = None
    bufferStartIndex = None
    matchedCount = 0

    with open(file_path, "r") as infile:
        lines = infile.readlines()
        idx = 0
        # we only care about the station names
        while "Station Names" not in lines[idx]:
            idx += 1

        while matchedCount < len(stations)+1:
            if idx < len(lines):
                while "data-text" not in lines[idx]:
                    idx += 1
                    if idx >= len(lines):
                        break

                if idx < len(lines):
                    line = lines[idx]
                    # print("parsing", line.strip())
                    # replace &amp; with an actual ampersand
                    letter = parse.parse('   data-text="{}"\n', line.replace("&amp;", "&")) # note: this is fragile to the number of spaces

                    if len(buffer) == 0:
                        bufferStartIndex = idx-1 # change this if the group tag position is offset

                    # ignore spaces
                    if letter[0] == " ":
                        idx += 1
                        continue

                    # if letter[0] == "ﬁ":
                    #     print("FUCKING LIGATURE DETECTED!!!")
                    #     print("GET THAT SHIT OUT OF HERE")
                    #     print("line ", idx)
                    #     exit(1)

                    buffer += letter[0]
                else:
                    print("no more lines")
                    buffer += "[EOF]" # add a spacer to buffer to prevent double matching
            else:
                print("no more lines")
                buffer += "[EOF]"

            print("buffer is", buffer)
            if buffer in stations.keys():
                print("Found new match:", buffer)
                lastMatchedName = buffer
                lastMatchedID = stations[buffer]
                lastMatchedIndex = idx+4

            if len(buffer) == longestName or idx >= len(lines):
                print("Buffer reached limit, restoring match", lastMatchedName, f"({matchedCount+1} of {len(stations)})")
                # create group around best match
                idx = bufferStartIndex
                # insert backwards as each item pushes forward further items
                lines.insert(idx, f'inkscape:label="{lastMatchedName.replace("&","")}">\n')
                lines.insert(idx, f'id="{lastMatchedID}"\n')
                lines.insert(idx, "<g\n")

                idx = lastMatchedIndex
                while ">" not in lines[idx]:
                    idx += 1
                idx += 1 # we want the group to be on the next line after the closing tag
                lines.insert(idx, "</g>\n")
                bufferStartIndex = idx+1 # now starts after the group tag
                buffer = ""

                idx = lastMatchedIndex
                matchedCount += 1

            idx += 1


        with open(out_path, "w") as outfile:
            outfile.writelines(lines)

def process_svg(svg_file_path, output_path, stations_path):
    with open(stations_path, "r") as stafile:
        stations = dict()
        for line in stafile.readlines():
            IDname = line.strip().split(":")
            stations[IDname[1].replace(" ", "")] = IDname[0] # remove all spaces since they are converted inconsistently

        butcher_svg_file(svg_file_path, output_path, stations)


if __name__ == "__main__":
    # Replace 'your_file.svg' with the path to your SVG file
    svg_file_path = '/home/yee/tubemap.svg'
    output_path = '/home/yee/tubemapgrouped.svg'
    stations_path = "stations.txt"

    process_svg(svg_file_path, output_path, stations_path)
    print("Done")
