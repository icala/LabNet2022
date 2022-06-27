import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DialogoInfoComponent } from 'src/app/shared/dialogo-info/dialogo-info.component';
import { Categoria } from '../../models/categoria';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.css'],
})
export class CrearComponent implements OnInit {
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

  get nameCtrl(): AbstractControl {
    return this.form.get('name')!;
  }
  get descriptionCtrl(): AbstractControl {
    return this.form.get('description')!;
  }

  limpiar(): void {
    if (this.nameCtrl) {
      this.nameCtrl.setValue('');
    }
    if (this.descriptionCtrl) {
      this.descriptionCtrl.setValue('');
    }
  }

  ngOnInit(): void {}

  onSubmitCrear(): void {
    // Crear Categoria
    var categoria = new Categoria();
    categoria.CategoryName = this.form.get('name')?.value;
    categoria.Description = this.form.get('description')?.value;

    this.categoriesService.crearCategoria(categoria).subscribe((res) => {
      this.form.reset();
      this.dialog.open(DialogoInfoComponent, {
        data: { title: 'Información', message: 'Categoria Creada' },
      });
      this.router.navigate(['/lista']);
    });
  }
}
