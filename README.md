# CADdyTools
Notepad++-Plugin for manipulate CADdy-formated  coordinate- and measure-textfiles

CADdy is a CAD-Software from dead german company ‘ZIEGLER Informatics GmbH’, but today continued by company’s ‘DataSolid’, ‘IGE+XAO-Group’ and ‘Wenninger Geoinformatik’. 
Se https://de.wikipedia.org/wiki/CADdy_(Software)

One part of this CADdy software is an very good surveying calculation tool. And this plugin can format and edit the exchange file for coordinates and measures. Many surveying engineers are using this format to exchange her measures.

## CADdy – column based coordinate format:

All numeric datas use the ‘point’[.] as decimal separator.
``` XML
pointnumber [SPACE] east-x-coordinate [SPACE] north-y-coordinate [SPACE] elevation-z-coordinate [SPACE] code [SPACE] descrition
```
Columns ‘code’ and ‘description’ are optional.

The exact text format is
```
PointABC            4410000.123   5700000.123     125.125  025
```

This plugin recognize the CADdy-coordinate-format on minimum:
Must at least 4 columns and column number 2-4 are must contains numeric values.

This tool can format the CADdy-coordinate or spreadsheet format. The spreadsheet format is separated by [TAB] and the decimal separator is [,].

Also an function from this plugin is change the code from any pointnumber or change ‘old code’ to ‘new code’. Yes I know your mind “that’s are is normally text replacement” but in surveying use many code’s are is plain numeric… 

This plugin can sort the coordinatelist by ervery column.

Another functions:

- compare two coordinatelist, point are equal by name
- calculate polarcoordinate from point-start to point-end: azimute, distance, clination,...
- calculate rotation around a point, set the direction (center-point to direction-point) to enter value.
- calculate translation all coordinates by east, north, elevation
- calculate tranformation source to destination. At least two equal points. Transformation is 4 param (3 translations east, north, elevation, 1 rotation arrount z-axis)


## CADdy - column based measure format
This format contains nativ measure datas point number, horizontal angle, zenith angle, distance, instrument height, reflector height, code and description.

example for measure:
```
-PB153               1.530 025
H16                116.32440   253.1630  101.12350   1.620 025
PB1091             310.34600    88.8650  100.44480   1.410 025
H2W03              215.87660   644.0340  101.11810   1.500 025
H2W03               15.87440   644.0330  298.87970   1.500 025
PB1091             110.34660    88.8650  299.55460   1.410 025
H16                316.32340   253.1630  298.86840   1.620 025
-PB153               1.530 025
H16                116.32440   253.1630  101.12190   1.620 025
PB1091             310.34720    88.8650  100.44400   1.410 025
H2W03              215.87650   644.0330  101.11890   1.500 025
H2W03               15.87460   644.0340  298.87900   1.500 025
PB1091             110.34670    88.8650  299.55560   1.410 025
H16                316.32330   253.1630  298.86830   1.620 025
```

Station point is [-XXXXX], on this example PB153. 
On station line is columns [pointnumber, instrument height, code, description]

For target lins are columns [pointnumber, horizontal angle, distance, vertical angle, reflector height, code, description]

The plugin can also change the code and set the point height, instrument - and reflector height to the sam value.
Formating to this CADdy-format, spreadsheet-format und make an CAPLAN-CADdy-format.
CAPLAN is a software from https://www.cremer.software/ for adjustment calculation. On this format has only one station line for!
example 
```
-PB153               1.530 025
H16                116.32440   253.1630  101.12350   1.620 025
PB1091             310.34600    88.8650  100.44480   1.410 025
H2W03              215.87660   644.0340  101.11810   1.500 025
H2W03               15.87440   644.0330  298.87970   1.500 025
PB1091             110.34660    88.8650  299.55460   1.410 025
H16                316.32340   253.1630  298.86840   1.620 025
H16                116.32440   253.1630  101.12190   1.620 025
PB1091             310.34720    88.8650  100.44400   1.410 025
H2W03              215.87650   644.0330  101.11890   1.500 025
H2W03               15.87460   644.0340  298.87900   1.500 025
PB1091             110.34670    88.8650  299.55560   1.410 025
H16                316.32330   253.1630  298.86830   1.620 025
```

## Settings page
Your can change the Values for define the 'CADdy' column format.
On general tab is [pointnumber] and the decimal seperator.
Checkbox for uppercase all Pointnumbers.

All values are base one "1", the first column is 1 (for the developers ;-) )!

Display in group boxes is one column with params 

Column (example pointnumber are 1)

startpoint in text file

maximal text length

decimalcounter (only by numeric values)


