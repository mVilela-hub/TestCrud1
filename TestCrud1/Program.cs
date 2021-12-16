// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

SqlConnection sqlConnection;
string connectionString = @"Data Source=.;Initial Catalog=FTI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
try
{
    Console.WriteLine("1 - Para inserir dados");
    Console.WriteLine("2 - Para visualizar os dados");
    Console.WriteLine("3 - Para atualizar os dados");
    Console.WriteLine("4 - Para deletar os dados");
    Console.Write("Digite a opção que deseja: ");
    int j = int.Parse(Console.ReadLine());

    if (j == 1)
    {
        //INSERT INTO
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        Console.WriteLine("Conectado com sucesso !!!");
        Console.WriteLine("Coloque o seu nome");
        string Nome = Console.ReadLine();
        Console.WriteLine("Coloque o seu sobrenome");
        string sobrenome = Console.ReadLine();
        string insertQuery = "INSERT INTO Nomes(Nome, sobrenome) VALUES('" + Nome + "', '" + sobrenome + "')";
        SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
        int i = insertCommand.ExecuteNonQuery();
        if (i > 0)
        {
            Console.WriteLine("Inserido no banco com sucesso !!!");
        }
        sqlConnection.Close();

    }

    else if (j == 2)
    {

        //SELECT *
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        Console.WriteLine("Conectado com sucesso !!!");
        string displayQuery = "SELECT * FROM Nomes";
        SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
        SqlDataReader dataReader = displayCommand.ExecuteReader();
        while (dataReader.Read())
        {
            Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
            Console.WriteLine("Nome: " + dataReader.GetValue(1).ToString());
            Console.WriteLine("Sobrenome: " + dataReader.GetValue(2).ToString());
        }
        displayCommand.ExecuteNonQuery();
        dataReader.Close();
        sqlConnection.Close();

    }

    else if (j == 3)
    {
        //UPDATE SET WHERE
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        Console.WriteLine("Conectado com sucesso !!!");
        int id;
        int choice;
        Console.Write("Digite o ID que deseja atualizar: ");
        id = int.Parse(Console.ReadLine());
        Console.Write("Você deseja alterar o Nome(1) ou o Sobrenome(2): ");
        choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            string nome;
            Console.Write("Digite novo nome: ");
            nome = Console.ReadLine();
            string updateQuery = "UPDATE Nomes SET Nome = '" + nome + "' WHERE Id = " + id + "";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            int i = updateCommand.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("Dado atualizado com Sucesso ");
            }
        }
        else if (choice == 2)
        {
            string sobrenome;
            Console.Write("Digite novo nome: ");
            sobrenome = Console.ReadLine();
            string updateQuery = "UPDATE Nomes SET sobrenome = '" + sobrenome + "' WHERE Id = " + id + "";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            int i = updateCommand.ExecuteNonQuery();
            if (i > 0)
            {
                Console.WriteLine("Dado atualizado com Sucesso ");
            }
        }
        else
        {
            Console.WriteLine("Opção Inválida !");
        }


    }
    else if (j == 4)
    {
        //DELETE
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        Console.WriteLine("Conectado com sucesso !!!");
        int id;
        Console.Write("Digite o ID que deseja deletar: ");
        id = int.Parse(Console.ReadLine());
        string deleteQuery = "DELETE FROM Nomes WHERE Id = " + id + "";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
        int i = deleteCommand.ExecuteNonQuery();
        if (i > 0)
        {
            Console.WriteLine("Dado deletado com sucesso !");

        }


    }
    else
    {
        Console.WriteLine("Opção inválida !");
    }
}

catch(Exception e)
{
    Console.WriteLine(e.Message);
}