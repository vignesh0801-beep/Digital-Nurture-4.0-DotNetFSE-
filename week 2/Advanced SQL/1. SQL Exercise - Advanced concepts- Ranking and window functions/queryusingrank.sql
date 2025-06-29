SELECT *
FROM (
    SELECT *,
           RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS rk
    FROM Products
) ranked
WHERE rk <= 3;
