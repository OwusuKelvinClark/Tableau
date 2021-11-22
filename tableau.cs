public class Tableau<T> {
	T[] contenu;
	int taille;
	
	public Tableau(int size) {
		/// Int size => La taille du tableau
		/// Initialises the table
		this.taille = size;
		contenu = new T[size];
	}
	
	public bool insert(T valeur, int index = 0){
		//// parameters: T valeur => Une valeur de type T (T est le type spécifié pour la table)
		/// int index: L'index ou on veut inserer la valeur (Defaut = 0)
		//// Inserer une valeur a un index specifier sinon le premier index
		Retourne true au cas ou l'index existe et false si l'index est grande que la taille du tableau
		if (index != null && index <= taille -1) {
			contenu[index] = valeur;
			return true;
		}
		return false;
	}
	
	public void supprimer(int index) {
		/// return type : void
		if (index >= taille) return;
		/// parameter: int => L'index d'element à suprimer
		for (int i=index; i<=taille-2; i++) {
			contenu[i] = contenu[i+1];
		}
	}
	
	public int? recherche(T valeur) {
		/// parameters: T valeur => La valeur a trouver
		/// return type int? => L'index du valeur s'il exite sinon une valeur null est retourner
		for (int i = 0; i<=taille-1;i++){
			if (EqualityComparer<T>.Default.Equals(contenu[i], valeur)) {
				return i;
			}
		}
		return null;
	}
	
	public void tri(bool inAscendingOrder = true) {
		/// parameters: bool => Pour déterminer si le tri doit être effectué par ordre croissant ou décroissant
		/// return type void
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
	
	public int Taille {
		/// parametre : void
		/// return type int => La taille du tableau
		get {return taille;}
	}
	
	public T getValue(int index) {
		/// parametre : int => L'index du valeur a retirer
		/// return type T => Retourner une valeur du type T ou null dans le cas l'index n'existe pas
		if (index < taille) {
			return contenu[index];
		}
		return default(T);
	}
	
	public void concatenation(Tableau<T> otherTable) {
		/// parametre Tableau<T> => Le tableau a concatener avec le tableau courant\
		/// return type void
		/// Concatène le tableau fourni à la fonction à la fonction courante
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
	
	public bool symetri() {
		/// parameters: None
		/// Returns: Boolean
		/// Renvoie vrai si le tableau est symétrique et faux lorsqu'il n'est pas symétrique
		if (contenu.Length % 2 != 0) return false;
		for (int i =0; i <= contenu.Length / 2; i++){
			if (!EqualityComparer<T>.Default.Equals(contenu[i],contenu[contenu.Length - i - 1])){
				return false;
			}
		}
		return true;
	}
}