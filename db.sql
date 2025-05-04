use aaa3
CREATE TABLE Players (
    PlayerID INT PRIMARY KEY IDENTITY(1,1),
    Login varchar(max) UNIQUE NOT NULL,
    Password varchar(max) NOT NULL,
    Email varchar(max) UNIQUE NOT NULL,
    Points INT DEFAULT 0
);

CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    PlayerID INT NOT NULL,
    Skin1 bit DEFAULT 0,
    Skin2 bit DEFAULT 0,
    Skin3 bit DEFAULT 0,
    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
);

CREATE TABLE Records (
    RecordID INT PRIMARY KEY IDENTITY(1,1),
    PlayerID INT NOT NULL,
    Login VARCHAR(50) NOT NULL,
    Points INT NOT NULL,
    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID)
);
