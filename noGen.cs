using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		
	}
}

public class Tableau {
	dynamic[] contenu;
	string type;
	
	public Tableau(int size, string type = "int") {
		this.type = type;
		switch(type) {
			case "int": contenu = new int[size] as dynamic;
				break;
			case "string": contenu = new string[size] as dynamic;
				break;
			default: contenu = new dynamic[size];
				break;
		}
	}
	
	public void insert(dynamic valeur, int index){
		if (index <= contenu.Length - 1){
			contenu[index] = valeur;
		}	
	}
	
	public void supprimer(int index) {
		if (index >= contenu.Length) return;
		
		for (int i=index; i<=contenu.Length - 2; i++) {
			contenu[index] = contenu[index+1];
		}
	}
	
	public void tri() {
			for (int i = 0; i<=contenu.Length - 1; i++) {
				for (int j=i+1; j<=contenu.Length-1; i++) {
					if (contenu[i] > contenu[j]) {
						int temp = contenu[i];
						contenu[i] = contenu[j];
						contenu[j] = temp;
					}
				}
			}
	}
	
	public int? recherche(dynamic valeur) {
		for (int i = 0; i<=contenu.Length-1;i++) {
			if (contenu[i] == valeur){
				return i;
			}
		}
		return null;
	}
}

