USE Geography

GO

SELECT 
	m.MountainRange
	,p.PeakName
	,p.Elevation 
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id 
-- AND m.MountainRange = 'Rila' - THIS INSTEAD OF WHERE
WHERE
	m.MountainRange = 'Rila'
ORDER BY
	p.Elevation DESC