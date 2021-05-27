SELECT TOP (3) pr.PartId,pr.Description,pn.Quantity AS [Required],pr.StockQty [In Stock],0 AS Ordered
	FROM Jobs AS j
	JOIN PartsNeeded AS pn ON pn.JobId = j.JobId
	JOIN Parts AS pr ON pr.PartId = pn.PartId
	WHERE j.[Status] != 'Finished' AND pn.Quantity > pr.StockQty