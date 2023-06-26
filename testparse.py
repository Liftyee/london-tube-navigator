import csv

coltitles = []
rows = []
with open("glondon_naptan.csv", "r") as datafile:
    # reader = csv.reader(datafile)
    # for row in reader:
    #     print(row)
    #     break
    rows = datafile.readlines()
    
    print(rows[0])

    for coltitle in rows[0].split(","):
        coltitles.append(coltitle.strip())
    
    print("Got column titles:", coltitles)

    for row in rows[1:]:
        if "Underground Station" in row:
            rows.append(row.split(",")[4].strip().replace(" Underground Station", ""))
    
    print("Got Tube stations:", rows)
