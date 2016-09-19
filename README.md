## _Band Tracker _
#### By _**Russ Vetsper**_




## Description/Specs

The Band Tracker app lets user keep track of bands , user can add , delete and list bands in venues .

** To run this app you will need to clone this repository. On your computers PowerShell run "DNU restore" . Enter "DNX Kestrel" then  Navigate in your browser to "LocalHost:5004" to enter the app.

** Creat database and tables:
* CREATE DATABASE band_tracker;
* GO
* USE band_tracker;
* GO
* CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE venues_bands (id INT IDENTITY(1,1), venue_id INT, band_id INT);
* GO

## Known Bugs


None

## Technologies Used
 C#, Nancy, Razor, html

### License
Copyright (c) 2016 _**Russ Vetsper **_
