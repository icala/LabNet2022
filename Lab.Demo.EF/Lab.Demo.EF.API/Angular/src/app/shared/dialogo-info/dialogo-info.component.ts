import { Component, OnInit, Inject, inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-dialogo-info',
  templateUrl: './dialogo-info.component.html',
  styleUrls: ['./dialogo-info.component.css'],
})
export class DialogoInfoComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit(): void {}
}
