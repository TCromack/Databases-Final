CREATE VIEW [dbo].[V_DakTest2]
	AS SELECT P.position,P.lastName,P.fName,P.team,s.pointsScored,s.passingTDs,s.passingYDs,s.passingINTs,s.rushingTDs,s.rushingYDs,
	s.receivingTDs,s.receivingYDs,s.receptions,s.fumblesLost,s.gamesPlayed FROM [stats] S INNER JOIN player P ON p.playerId = s.Player_playerId
	WHERE p.fName LIKE '%Dak%'
	