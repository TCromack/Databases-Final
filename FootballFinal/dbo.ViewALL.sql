CREATE VIEW [dbo].[PlayersWithStats]
	AS SELECT P.position,P.lastName,P.fName,P.team,s.pointsScored,s.passingTDs,s.passingYDs,s.passingINTs,s.rushingTDs,s.rushingYDs,s.receivingTDs,s.receivingYDs,s.receptions,s.fumblesLost,s.gamesPlayed FROM [player] P INNER JOIN stats S ON P.playerId = s.Player_playerId

