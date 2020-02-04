CREATE VIEW [dbo].[V_WR]
	AS SELECT * FROM [player] INNER JOIN stats ON playerId = Player_playerId
	WHERE position = 'WR'
