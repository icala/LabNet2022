import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Categoria } from '../../models/categoria';
import { CategoriesService } from '../../services/categories.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { DialogoInfoComponent } from 'src/app/shared/dialogo-info/dialogo-info.component';
@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css'],
})
export class ListaComponent implements OnInit, OnDestroy {
  public categorias: Array<Categoria> = [];
  private categoriasObs?: Subscription;
  private borrarObs?: Subscription;
  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obtenerCategorias();
  }

  obtenerCategorias() {
    this.categoriasObs = this.categoriesService
      .obtenerCategorias()
      .subscribe((res) => {
        this.categorias = res;
      });
  }

  irAEditar(categoria: Categoria) {
    this.categoriesService.categoriaAEditar = categoria;
    this.router.navigate(['/editar']);
  }

  borrarCategoria(categoria: Categoria) {
    this.borrarObs = this.categoriesService
      .borrarCategoria(categoria)
      .subscribe({
        next: (res) => {
          this.dialog.open(DialogoInfoComponent, {
            data: { title: 'Información', message: 'Categoria Borrada' },
          });
          this.obtenerCategorias();
        },
        error: (error) => {
          this.dialog.open(DialogoInfoComponent, {
            data: { title: 'Error', message: error.error.Message },
          });
        },
      });
  }

  ngOnDestroy() {
    this.categoriasObs?.unsubscribe();
    this.borrarObs?.unsubscribe();
  }
}
