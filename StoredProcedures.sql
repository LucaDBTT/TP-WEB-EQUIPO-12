/*Consulta general*/
create procedure ListarConSP as
SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, 
       m.Descripcion as MarcaDescripcion, a.IdMarca, 
       c.Descripcion as CategoriaDescripcion, a.IdCategoria, 
       i.ImagenUrl
FROM ARTICULOS a 
INNER JOIN MARCAS m ON a.IdMarca = m.Id 
LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id
LEFT JOIN IMAGENES i ON a.Id = i.IdArticulo
WHERE (i.Id IS NULL OR i.Id = (SELECT TOP 1 Id FROM IMAGENES WHERE IdArticulo = a.Id ORDER BY Id));


/* Para obtener mas de una imagen*/
CREATE PROCEDURE ObtenerDatosPorId
    @Id INT
AS
BEGIN
    SELECT *
    FROM IMAGENES
    WHERE IdArticulo = @Id;
END;