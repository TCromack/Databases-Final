CREATE VIEW [dbo].[V_RB]
	AS SELECT * FROM [player] INNER JOIN stats ON playerId = Player_playerId
	WHERE position = 'RB'


