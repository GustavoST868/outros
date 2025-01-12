// Used libraries
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.IO;



//class to store the data
class Store
{
    // Attributes
    List<string> datatext = new List<string>();
    List<string> datanumber = new List<string>();
    List<string> datacompound = new List<string>();

    public Store() { }

    //method for entering data
    public void insert_filter(string data)
    {
        CheckType ct = new CheckType();
        int type = ct.CheckTypeFunction(data);

        switch (type)
        {
            case 0:
                datanumber.Add(data);
                break;

            case 1:
                datatext.Add(data);
                break;

            case -1:
                datacompound.Add(data);
                break;
        }
    }

    //method to remove data
    public void remove(string data)
    {
        CheckType ct = new CheckType();
        int type = ct.CheckTypeFunction(data);

        switch (type)
        {
            case 0:
                datanumber.Remove(data);
                break;

            case 1:
                datatext.Remove(data);
                break;

            case -1:
                datacompound.Remove(data);
                break;
        }
    }

    //method for searching data
    public void search(string data)
    {
        CheckType ct = new CheckType();
        int type = ct.CheckTypeFunction(data);

        switch (type)
        {
            case 0:
                if (datanumber.Contains(data) == true)
                {
                    Console.WriteLine("\nDado encontrado!\n");
                }
                break;

            case 1:
                if (datatext.Contains(data) == true)
                {
                    Console.WriteLine("\nDado encontrado!\n");
                }
                break;

            case -1:
                if (datacompound.Contains(data) == true)
                {
                    Console.WriteLine("\nDado encontrado!\n");
                }
                break;
        }
    }


    //method to obtain data
    public string get(string data)
    {
        if (datanumber.Contains(data) || datatext.Contains(data) || datacompound.Contains(data))
        {
            return data;
        }
        else
        {
            return null;
        }
    }

    //method to show data
    public void print()
    {
        Console.WriteLine("\nDataNumber:");
        foreach (var number in datanumber)
        {
            Console.Write("|" + number + "|");
        }

        Console.WriteLine("\n\nDataText:");
        foreach (var text in datatext)
        {
            Console.WriteLine("|" + text + "|");
        }

        Console.WriteLine("\nDataCompound:");
        foreach (var compound in datacompound)
        {
            Console.WriteLine("|" + compound + "|");
        }
    }

    //method to save data
    public void save( )
    {
        StringBuilder string_data = new StringBuilder();
        
        string_data.Append("\nDatatext = [");
        foreach (string item in datatext)
        {
            string_data.Append(item);
        }
        string_data.Append("];");

        string_data.Append("\nDatanumber = [");
        foreach (string item in datanumber)
        {
            string_data.Append(item);
        }
        string_data.Append("];");

        string_data.Append("\nDatacompound = [");
        foreach (string item in datacompound)
        {
            string_data.Append(item);
        }
        string_data.Append("];");

        try
        {

            using (StreamWriter sr = new StreamWriter(Environment.CurrentDirectory))
            {
                sr.Write(string_data.ToString());
            }

        }catch(Exception ex)
        {
            Console.WriteLine("Erro ao salvar o arquivo!");
        }

        
    }

    //get text list
    public List<string> Getdatatext()
    {
        return datatext;
    }

    //get number list
    public List<string> Getdatanumber()
    {
        return datanumber;
    }

    //get list of composite data
    public List<string> Getdatacompound()
    {
        return datacompound;
    }
}


//class to check data type
class CheckType
{
    public CheckType() { }

    //check data
    public int CheckTypeFunction(string data)
    {
        // number
        if (Regex.IsMatch(data, @"^\d+$"))
        {
            return 0;
        }
        // text
        else if (Regex.IsMatch(data, @"^[a-zA-Z]+$"))
        {
            return 1;
        }
        // compound
        else
        {
            return -1;
        }
    }
}

//class to extract statistical data
class Analyze
{
    // Attributes
    List<string> datatextcopy = new List<string>();
    List<string> datanumbercopy = new List<string>();
    List<string> datacompoundcopy = new List<string>();

    public Analyze(
        List<string> datatext,
        List<string> datacompound,
        List<string> datanumber
        )
    {
        datatextcopy = datatext;
        datacompoundcopy = datacompound;
        datanumbercopy = datanumber;
    }

    //get media
    public double media()

    {
        List<double> datanumber = new List<double>();

        foreach (string value in datanumbercopy)
        {
            datanumber.Add(double.Parse(value));
        }

        double sum = 0;

        // empty list
        if (datanumber.Count == 0)
        {
            return 0;
        }

        foreach (double value in datanumber)
        {
            sum += value;
        }

        // media
        double media = sum / datanumber.Count;
        return media;
    }

    //get variance
    public double variance()
    {

        List<double> datanumber = new List<double>();

        foreach (string value in datanumbercopy)
        {
            datanumber.Add(double.Parse(value));
        }

        if (datanumber.Count < 2)
        {
            throw new ArgumentException("A variância requer pelo menos dois valores.");
        }


        double Mean = media();


        double sumSquaredDifferences = 0;

        foreach (double value in datanumber)
        {
            double difference = value - Mean;
            sumSquaredDifferences += difference * difference;
        }

        double variance = sumSquaredDifferences / (datanumber.Count - 1);

        return variance;
    }

    //get standard deviation
    public double standardDeviation()
    {
        return Math.Sqrt(variance());
    }


    //get frequency
    public int frequency(string datatext)
    {
        int contador = 0;

        CheckType ct = new CheckType();
        int type = ct.CheckTypeFunction(datatext);

        switch (type)
        {
            case 0:
                foreach (string data in datanumbercopy)
                {
                    if (datatext == data)
                    {
                        contador++;
                    }
                }
                return contador;
                break;

            case 1:
                foreach (string data in datatextcopy)
                {
                    if (datatext == data)
                    {
                        contador++;
                    }
                }
                return contador;
                break;

            case -1:
                foreach (string data in datacompoundcopy)
                {
                    if (datatext == data)
                    {
                        contador++;
                    }
                }
                return contador;
                break;

            default:
                return contador;
        }
    }
}

//main class program
class Program
{
    static void Main()
    {
        //testing the Store Class 
        Store store = new Store();
        store.insert_filter("1");
        store.insert_filter("4");
        store.insert_filter("20");
        store.insert_filter("2a");
        store.insert_filter("a");
        store.print();
        store.save();
        store.search("a");

        

        //testing the Analyze Class 
        Analyze analyze = new Analyze(store.Getdatatext(), store.Getdatacompound(), store.Getdatanumber());
        Console.WriteLine("Media = |" + analyze.media() + "|");
    }
}
