CREATE TABLE player (
  playerId int NOT NULL,
  fName varchar(45) NOT NULL,
  lastName varchar(45) NOT NULL,
  position varchar(2) NOT NULL,
  team varchar(45) NOT NULL,
  PRIMARY KEY (playerId)
) 

CREATE TABLE stats (
  pointsScored int DEFAULT 0,
  gamesPlayed int DEFAULT 0 ,
  Player_playerId int NOT NULL,
  rushingTDs int DEFAULT 0,
  rushingYDs int DEFAULT 0,
  fumblesLost int DEFAULT 0 ,
  receptions int DEFAULT 0,
  receivingTDs int DEFAULT 0,
  receivingYDs int DEFAULT 0,
  passingYDs int DEFAULT 0,
  passingINTs int DEFAULT 0,
  passingTDs int DEFAULT 0,
  Year int DEFAULT 0,
  Week varchar(45) DEFAULT NULL,
  statsID int DEFAULT 0,
  PRIMARY KEY (Player_playerId,statsID),
  CONSTRAINT fk_Stats_Player FOREIGN KEY (Player_playerId) REFERENCES player (playerId)
)