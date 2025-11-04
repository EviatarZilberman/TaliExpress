import { Component, OnInit } from '@angular/core';
import { PokemonService } from '../services/pokemon-service.service';
import { Pokemon } from '../../../Classes/Pokemon';

@Component({
  selector: 'app-pokemon-template-form',
  standalone: false,
  templateUrl: './pokemon-template-form.component.html',
  styleUrl: './pokemon-template-form.component.css'
})
export class PokemonTemplateFormComponent implements OnInit {
  pokemon!: Pokemon;
  constructor(private pokemonService: PokemonService) { }

  ngOnInit() {
    this.pokemonService.getPokemon(2).subscribe((data: Pokemon) => {
      this.pokemon = data;
    });
  }
}
