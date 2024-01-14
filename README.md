# tube-challenge-router
Program to find potential routes for the Tube Challenge (visit all stations on the London Underground by train). 

Uses Simulated Annealing to optimize route. Populates and caches graph structure automatically from the TfL API. 

`TubeChallengeRouter/` contains the main route optimiser and GUI.
`tube-map-svgs/` contains my modified SVG files for a simplified Tube map.
`svgTubeMap/` contains the Python code used to generate the SVG file with SVG objects grouped by station name. 
