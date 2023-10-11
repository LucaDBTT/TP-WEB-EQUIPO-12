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
                string consulta = "select Codigo, Nombre, A.Descripcion, M.Descripcion as MarcaDescripcion, C.Descripcion as CategoriaDescripcion,Precio,I.ImagenUrl, A.IdCategoria, A.IdMarca, \r\nA.Id from ARTICULOS as A, CATEGORIAS as C, MARCAS as M, IMAGENES as I  \r\nwhere C.Id = A.IdCategoria and M.Id = A.IdMarca and I.IdArticulo = A.Id and ";
                switch (campo)
                {

                    case "Marca":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":

                                consulta += "M.Descripcion like '%" + filtroAvanzado + "%'";

                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":
                                consulta += "C.Descripcion like '%" + filtroAvanzado + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Contiene las letras: ":
                                consulta += "A.Nombre like '%" + filtroAvanzado + "%'";
                                break;
                        }
                        break;

                }

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Precio mayor a: ":
                            consulta += "Precio > " + filtroAvanzado;
                            break;

                        case "Precio menor a: ":
                            consulta += "Precio < " + filtroAvanzado;
                            break;
                    }

                }

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
    }
}

        

