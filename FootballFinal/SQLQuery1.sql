
DROP TABLE IF EXISTS player;

CREATE TABLE player (
  playerId int(11) NOT NULL,
  fName varchar(45) NOT NULL,
  lastName varchar(45) NOT NULL,
  position varchar(2) NOT NULL,
  team varchar(45) NOT NULL,
  PRIMARY KEY (playerId)
) 






DROP TABLE IF EXISTS stats;

CREATE TABLE stats (
  pointsScored int(11) NOT NULL,
  gamesPlayed varchar(45) NOT NULL,
  Player_playerId int(11) NOT NULL,
  rushingTDs int(11) NOT NULL,
  rushingYDs int(11) NOT NULL,
  fumblesLost int(11) DEFAULT NULL,
  receptions int(11) DEFAULT NULL,
  receivingTDs int(11) DEFAULT NULL,
  receivingYDs int(11) DEFAULT NULL,
  passingYDs int(11) DEFAULT NULL,
  passingINTs int(11) DEFAULT NULL,
  passingTDs int(11) DEFAULT NULL,
  Year int(11) DEFAULT NULL,
  Week varchar(45) DEFAULT NULL,
  statsID int(11) NOT NULL,
  PRIMARY KEY (Player_playerId,statsID),
  CONSTRAINT fk_Stats_Player FOREIGN KEY (Player_playerId) REFERENCES player (playerId)
) 



