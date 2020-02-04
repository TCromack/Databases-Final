CREATE VIEW [dbo].[V_TE]
	AS SELECT * FROM [player] INNER JOIN stats ON playerId = Player_playerId
	WHERE position = 'TE'
