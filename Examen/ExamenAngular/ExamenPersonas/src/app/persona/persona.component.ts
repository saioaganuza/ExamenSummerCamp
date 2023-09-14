import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from '../services/persona.service';
import { Subscription } from 'rxjs';
import { IPersonaForCreationDTO } from '../interfaces/persona-for-creation-dto';
import { IPersonaGetDTO } from '../interfaces/persona-get-dto';


@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent {
  login: FormGroup;
  sub!: Subscription;
  listaPersonas: IPersonaGetDTO[] = [];

  constructor(private fb: FormBuilder, private personaService: PersonaService) {
    this.login = this.fb.group({
      nombre: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      telefono: ['']
    });

    this.getPersonas();
  }

  log(): void {
    const persona: IPersonaForCreationDTO = {
      nombre: this.login.value.nombre,
      fechaDeNacimiento: this.login.value.fechaNacimiento,
      telefono: this.login.value.telefono
    };
    this.sub = this.personaService.postPersona(persona)
      .subscribe({
        next: (data: any) => {
          this.getPersonas();
        },
        error: () => {
          console.log("Persona no añadida");
        }
      });
  }

  getPersonas(): void {
    this.sub = this.personaService.getPersonas()
      .subscribe({
        next: (data) => {
          if(data.length > 0){
            this.listaPersonas = data;
          }
        },
        error: () => {
          console.log("Personas no recogidas");
        }
      });
  }

  ngOnDestroy(): void {
    if(this.sub != null && this.sub != undefined){
      this.sub.unsubscribe();
    }
  }
}
