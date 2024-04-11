import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-author-form',
  templateUrl: './author-form.component.html',
  styleUrl: './author-form.component.scss'
})
export class AuthorFormComponent {
  meuFormulario!: FormGroup;



  constructor(private fb: FormBuilder) { }
}
