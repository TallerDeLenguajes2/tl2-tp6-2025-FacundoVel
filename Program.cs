using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }

    //insertar un producto
    string insertProducto = "INSERT INTO Productos (Descripcion, Precio) VALUES ('Mouse Inalambrico Logitech', 5000.0)";
    using (SqliteCommand cmd = new SqliteCommand(insertProducto, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Producto insertado correctamente.");
    }

    //Insertar un presupuesto
    string insertPresupuesto = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES ('Carlos Ruiz', '2024-10-25')";
    using (SqliteCommand cmd = new SqliteCommand(insertPresupuesto, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Presupuesto insertado correctamente.");
    }

    //insertar registros en PresupuestoDetalle
    string insertDetalle = "INSERT OR IGNORE INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES (1, 3, 2)";
    using (SqliteCommand cmd = new SqliteCommand(insertDetalle, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Detalle insertado correctamente.");
    }

    //Modificar un Producto
    string updateProducto = "UPDATE Productos SET Descripcion = 'Teclado Mecanico Logitech', Precio = 12000 WHERE idProducto = 3";
    using (SqliteCommand cmd = new SqliteCommand(updateProducto, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Se modifico un producto Correctamente");
    }

    //Modificar NombreDestinatario de Presupuesto
    String updatePresupuesto = "UPDATE Presupuestos SET NombreDestinatario = 'Luis Fernandez' WHERE idPresupuesto = 1";
    using (SqliteCommand cmd = new SqliteCommand(updatePresupuesto, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Presupuesto actualizado");
    }

    //Eliminar un registro de PresupuestoDetalle
    string deleteDetalle = "DELETE FROM PresupuestosDetalle WHERE idPresupuesto = 1 AND idProducto = 2";
    using (SqliteCommand cmd = new SqliteCommand(deleteDetalle, connection))
    {
        cmd.ExecuteNonQuery();
        Console.WriteLine("Registro Eliminado");
    }

    Console.WriteLine("\nTABLA: Productos");
    string selectProductos = "SELECT * FROM Productos";
    using (SqliteCommand cmd = new SqliteCommand(selectProductos, connection))
    using (SqliteDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["idProducto"]} | Descripcion: {reader["Descripcion"]} | Precio: {reader["Precio"]}");
        }
    }

    Console.WriteLine("\nTABLA: Presupuestos");
    string selectPesupuestos = "SELECT * FROM Presupuestos";
    using (SqliteCommand cmd = new SqliteCommand(selectPesupuestos, connection))
    using (SqliteDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["idPresupuesto"]} | Nombre: {reader["NombreDestinatario"]} | Fecha: {reader["FechaCreacion"]}");
        }
    }

    Console.WriteLine("\nTABLA: PresupuestosDetalle");
    string selectDetalles = "SELECT * FROM PresupuestosDetalle";
    using (SqliteCommand cmd = new SqliteCommand(selectDetalles, connection))
    using (SqliteDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"idPresupuesto: {reader["idPresupuesto"]} | idProducto: {reader["idProducto"]} | Cantidad: {reader["Cantidad"]}");
        }
    }

    connection.Close();
    Console.WriteLine("desconexion de la db :)");
}