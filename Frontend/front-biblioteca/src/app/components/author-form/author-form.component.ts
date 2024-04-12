import { Component, EventEmitter, Input, Output, output} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { authorService } from '../../services/author.service';
import { Author } from '../../models/author';

@Component({
  selector: 'app-author-form',
  templateUrl: './author-form.component.html',
  styleUrl: './author-form.component.scss'
})
export class AuthorFormComponent {

  @Output() ExportarFormulario = new EventEmitter<Author>();
  @Input() BtnAcao!: string;
  @Input() BtnTitulo!: string;

  meuFormulario!: FormGroup;


  constructor(private authorService:authorService) { }

  ngOnInit(): void{
    this.meuFormulario = new FormGroup({
      name: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      email:new FormControl('', Validators.required)
    });
  }

  Imprimir(){
    this.ExportarFormulario.emit(this.meuFormulario.value);
}

}
