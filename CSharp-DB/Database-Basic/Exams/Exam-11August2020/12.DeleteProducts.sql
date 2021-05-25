CREATE TRIGGER tr_InstedDeleteOnProducts
ON Products INSTEAD OF DELETE
AS
	DELETE FROM Feedbacks
		WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
		WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM Products
		WHERE Id IN (SELECT Id FROM deleted)


DELETE FROM Products WHERE Id = 7