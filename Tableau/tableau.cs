using System;
using System.Collections.Generic;

public class Tableau<T> {
	T[] contenu;
	int taille;

    /// <summary>Initializes a new instance of the <see cref="Tableau{T}" /> class.</summary>
    /// <param name="size">The size.</param>
    public Tableau(int size) {
		this.taille = size;
		contenu = new T[size];
	}

    /// <summary>Inserts the specified valeur at the specified index in the table</summary>
    /// <param name="valeur">The valeur.</param>
    /// <param name="index">The index.</param>
    /// <returns>
    ///   bool
    /// </returns>
    public bool insert(T valeur, int index = 0){
		if (index <= taille -1) {
			contenu[index] = valeur;
			return true;
		}
		return false;
	}

    /// <summary>Deletes the value at the specified index</summary>
    /// <param name="index">The index.</param>
    public void supprimer(int index) {
		if (index >= taille) return;
		for (int i=index; i<=taille-2; i++) {
			contenu[i] = contenu[i+1];
		}
	}

    /// <summary>Searchs for the specified value in the table</summary>
    /// <param name="valeur">The valeur.</param>
    /// <returns>
    ///   int?
    /// </returns>
    public int? recherche(T valeur) {
		for (int i = 0; i<=taille-1;i++){
			if (EqualityComparer<T>.Default.Equals(contenu[i], valeur)) {
				return i;
			}
		}
		return null;
	}

    /// <summary>Sorts the table</summary>
    /// <param name="inAscendingOrder">if set to <c>true</c> [in ascending order].</param>
    public void tri(bool inAscendingOrder = true) {
		T[] newTable = new T[taille];
		Array.Copy(contenu, newTable, contenu.Length);
		for (int i = 0; i<=taille-1;i++) {
			for (int j=i+1; j<=taille-1; j++){
				if (Comparer<T>.Default.Compare(newTable[j], newTable[i]) < 0){
					T temp = newTable[i];
					newTable[i] = newTable[j];
					newTable[j] = temp;			
				}
			}
		}
		
		if (!inAscendingOrder) {
			Array.Reverse<T>(newTable);
		}
		contenu = newTable;
	}

    /// <summary>Gets the size of the table.</summary>
    /// <value>The taille.</value>
    public int Taille {
		get {return taille;}
	}

    /// <summary>Gets the value at the specified index</summary>
    /// <param name="index">The index.</param>
    /// <returns>
    ///   T?
    /// </returns>
    public T getValue(int index) {
		if (index < taille) {
			return contenu[index];
		}
		return default(T);
	}

    /// <summary>Concantenates a table of the same type as the current to it</summary>
    /// <param name="otherTable">The other table.</param>
    public void concatenation(Tableau<T> otherTable) {
		int localSize = contenu.Length;
		int otherTableSize = otherTable.Taille;
		T[] newTable = new T[localSize + otherTableSize];
		
		for (int i = 0; i <= otherTable.Taille - 1; i++){
			newTable[i] = contenu[i];
		}
		
		int currIndex = (newTable.Length - localSize) - 1;
		for (int i=0; i<=otherTableSize-1;i++){
			newTable[currIndex++] = otherTable.contenu[i];
		}
		
		contenu = newTable;
	}

    /// <summary>Checks if the table is symetric</summary>
    /// <returns>
    ///   bool
    /// </returns>
    public bool symetrie() {
		if (contenu.Length % 2 != 0) return false;
		for (int i =0; i <= contenu.Length / 2; i++){
			if (!EqualityComparer<T>.Default.Equals(contenu[i],contenu[contenu.Length - i - 1])){
				return false;
			}
		}
		return true;
	}
}