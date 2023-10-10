Select pr.ProductName 'Имя продукта', ct.CategoryName 'Имя категории' 
FROM Products pr
LEFT OUTER JOIN dbo.CategoriesProducts cp
ON cp.ProductsId = pr.Id
Left OUTER JOIN Categories ct
ON ct.id = cp.CategoriesId 

