using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;


namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> Lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearQuery("select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, m.Descripcion as MarcaDescripcion, a.IdMarca, c.Descripcion as CategoriaDescripcion, a.IdCategoria, im.ImagenUrl from ARTICULOS a INNER join IMAGENES im ON a.Id= im.IdArticulo INNER JOIN MARCAS m ON a.IdMarca = m.Id LEFT JOIN CATEGORIAS c ON a.IdCategoria = c.Id");
                datos.EjecutarLectura();
                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.lector["Id"];
                    aux.CodigoArticulo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.lector["MarcaDescripcion"];
                    aux.Marca.IdMarca = (int)datos.lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.ImagenUrl = new Imagen();

                    if (datos.lector["CategoriaDescripcion"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.lector["CategoriaDescripcion"];
                        aux.Categoria.IdCategoria = (int)datos.lector["IdCategoria"];
                    }

                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl.Descripcion = (string)datos.lector["ImagenUrl"];

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(Articulo nuevo)
        {
            try
            {
                using (AccesoDatos Datos = new AccesoDatos())
                {
                    ImagenNegocio negocioImagen = new ImagenNegocio();
                    Imagen imagen = new Imagen();

                    Datos.SetearQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion,IdMarca,IdCategoria,Precio) VALUES ('" + nuevo.CodigoArticulo + "','" + nuevo.Nombre + "', '" + nuevo.Descripcion + "',@IdMarca,@IdCategoria, " + nuevo.Precio + ")");
                    Datos.setearParametros("@IdMarca", nuevo.Marca.IdMarca);
                    Datos.setearParametros("@IdCategoria", nuevo.Categoria.IdCategoria);
                    Datos.ejecutarAccion();

                    imagen = negocioImagen.getImagen(); // Obtener el IdArticulo del artículo recién insertado

                    // Insertar la imagen en la tabla IMAGENES
                    Datos.SetearQuery("INSERT INTO IMAGENES(IdArticulo, ImagenUrl) VALUES(@IdArticulo, @ImagenUrl)");
                    Datos.setearParametros("@IdArticulo", imagen.IdArticulo);
                    Datos.setearParametros("@ImagenUrl", nuevo.ImagenUrl.Descripcion);
                    Datos.ejecutarAccion();
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Modificar(Articulo nuevo)
        {
            AccesoDatos Datos = new AccesoDatos();
            ImagenNegocio negocioImagen = new ImagenNegocio();
            Imagen imagen = new Imagen();

            try
            {
                Datos.SetearQuery("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @IdArticulo");
                Datos.setearParametros("@Codigo", nuevo.CodigoArticulo);
                Datos.setearParametros("@Nombre", nuevo.Nombre);
                Datos.setearParametros("@Descripcion", nuevo.Descripcion);
                Datos.setearParametros("@IdMarca", nuevo.Marca.IdMarca);
                Datos.setearParametros("@IdCategoria", nuevo.Categoria.IdCategoria);
                Datos.setearParametros("@Precio", nuevo.Precio);
                Datos.setearParametros("@IdArticulo", nuevo.IdArticulo);
                Datos.ejecutarAccion();


                Datos.SetearQuery("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo2");
                Datos.setearParametros("@ImagenUrl", nuevo.ImagenUrl.Descripcion);
                Datos.setearParametros("@IdArticulo2", nuevo.IdArticulo);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
        public void bajaFisica(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            DialogResult dialogo = MessageBox.Show("Esta seguro que desea eliminar el articulo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            try
            {
                if (dialogo == DialogResult.Yes)
                {
                    datos.SetearQuery("delete from ARTICULOS where Id = @id");
                    datos.setearParametros("@id", id);
                    datos.ejecutarAccion();
                    MessageBox.Show("Articulo eliminado con exito");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Articulo> filtrar(string campo, string criterio, string filtroAvanzado)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS MarcaDescripcion, C.Descripcion AS CategoriaDescripcion, A.Precio, MAX(I.ImagenUrl) AS ImagenUrl, A.IdCategoria, A.IdMarca, A.Id " +
                 "FROM ARTICULOS AS A " +
                 "INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id " +
                 "INNER JOIN MARCAS AS M ON A.IdMarca = M.Id " +
                 "INNER JOIN IMAGENES AS I ON I.IdArticulo = A.Id " +
                 "WHERE C.Id = A.IdCategoria AND M.Id = A.IdMarca AND I.IdArticulo = A.Id ";

                switch (campo)
                {
                    case "Marca":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":
                                consulta += "AND M.Descripcion LIKE '%" + filtroAvanzado + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":
                                consulta += "AND C.Descripcion LIKE '%" + filtroAvanzado + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":
                                consulta += "AND A.Nombre LIKE '%" + filtroAvanzado + "%'";
                                break;
                        }
                        break;
                }

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Precio mayor a: ":
                            consulta += "AND A.Precio > " + filtroAvanzado;
                            break;
                        case "Precio menor a: ":
                            consulta += "AND A.Precio < " + filtroAvanzado;
                            break;
                    }
                }

                consulta += " GROUP BY A.Codigo, A.Nombre, A.Descripcion, M.Descripcion, C.Descripcion, A.Precio, A.IdCategoria, A.IdMarca, A.Id";

                datos.SetearQuery(consulta);
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.lector["Id"];
                    aux.CodigoArticulo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.lector["MarcaDescripcion"];
                    aux.Marca.IdMarca = (int)datos.lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.ImagenUrl = new Imagen();

                    if (datos.lector["CategoriaDescripcion"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.lector["CategoriaDescripcion"];
                        aux.Categoria.IdCategoria = (int)datos.lector["IdCategoria"];
                    }

                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl.Descripcion = (string)datos.lector["ImagenUrl"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public List<Articulo> ListarConSP()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("ListarConSP");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.lector["Id"];
                    aux.CodigoArticulo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Precio = (decimal)datos.lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.lector["MarcaDescripcion"];
                    aux.Marca.IdMarca = (int)datos.lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.ImagenUrl = new Imagen();

                    if (datos.lector["CategoriaDescripcion"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.lector["CategoriaDescripcion"];
                        aux.Categoria.IdCategoria = (int)datos.lector["IdCategoria"];
                    }

                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl.Descripcion = (string)datos.lector["ImagenUrl"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}

        

