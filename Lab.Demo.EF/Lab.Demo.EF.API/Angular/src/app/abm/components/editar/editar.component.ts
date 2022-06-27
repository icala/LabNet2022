import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DialogoInfoComponent } from 'src/app/shared/dialogo-info/dialogo-info.component';
import { Categoria } from '../../models/categoria';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css'],
})
export class EditarComponent implements OnInit {
  form: FormGroup;

  constructor(
    private readonly fb: FormBuilder,
    private categoriesService: CategoriesService,
    private dialog: MatDialog,
    private router: Router
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.cargarCategoriaAEditar();
  }

  cargarCategoriaAEditar() {
    var cat = this.categoriesService.categoriaAEditar;
    this.form.get('name')?.setValue(cat.CategoryName);
    this.form.get('description')?.setValue(cat.Description);
  }

  onSubmitEditar() {
    var categoria = new Categoria();
    categoria.CategoryID = this.categoriesService.categoriaAEditar.CategoryID;
    categoria.CategoryName = this.form.get('name')?.value;
    categoria.Description = this.form.get('description')?.value;

    this.categoriesService.editarCategoria(categoria).subscribe((res) => {
      this.form.reset();
      this.dialog.open(DialogoInfoComponent, {
        data: { title: 'Información', message: 'Categoria Editada' },
      });
      this.router.navigate(['/lista']);
    });
  }
}
