import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Categoria } from '../models/categoria';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  endpoint: string = 'categories';

  categoriaAEditar: Categoria = new Categoria();

  constructor(private http: HttpClient) {}

  public crearCategoria(categoria: Categoria): Observable<any> {
    let url = environment.api + this.endpoint;
    return this.http.post(url, categoria);
  }

  public obtenerCategorias(): Observable<Array<Categoria>> {
    let url = environment.api + this.endpoint;
    return this.http.get<Array<Categoria>>(url);
  }

  public borrarCategoria(categoria: Categoria): Observable<any> {
    let url = environment.api + this.endpoint + '/' + categoria.CategoryID;
    return this.http.delete(url);
  }

  public editarCategoria(categoria: Categoria): Observable<any> {
    let url = environment.api + this.endpoint + '/' + categoria.CategoryID;
    return this.http.patch(url, categoria);
  }
}
