# _Shoe Stores_

#### _A Site that Lists Shoe Brands and the Stores that Sell Them, 3/8/2016_

#### By _**Michael Dada**_

## Description

_This site allows the user to create a list of shoe stores and add a list of brands that are for sale there.  They can then list all available shoe brands and see which stores carry them, and add new sellers to a brand.  They can also edit and delete the store names, or delete the whole list of stores if necessary._

## Setup/Installation Requirements
* _To create your own database:
    In SQLCMD:
    CREATE DATABASE shoe_stores;
    GO
    USE shoe_stores;
    GO
    CREATE TABLE stores (id INT IDENTITY(1,1), name VARCHAR(255));
    CREATE TABLE brands (id INT IDENTITY(1,1), name VARCHAR(255));
    GO_

* _In Powershell, run dnu restore_
* _To start server, run dnx kestrel_
* _Navigate to localhost:5004_
* _Enjoy!_


## Known Bugs

_There are no known bugs at this time_

## Support and contact details

_You can contact me with questions or comments at mail.michaeldada@gmail.com_

## Technologies Used

_C#, MySQL, SSMS, Razor, Nancy, Powershell, Atom_

### License

*MIT License*

Copyright (c) 2016 **_Michael Dada_**
