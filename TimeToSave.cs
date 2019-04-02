using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[Serializable] //Atrybut Serializable sprawia że obiekt tej klasy będzie mógł być zapisany do pliku
public class TimeToSave 
{
    public Time[] time; //Klasa przechowuje tablicę obiektów Time 
}