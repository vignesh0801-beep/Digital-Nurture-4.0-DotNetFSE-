SELECT *
FROM (
    SELECT *,
           DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS drk
    FROM Products
) ranked
WHERE drk <= 3;
