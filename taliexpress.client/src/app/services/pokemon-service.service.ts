/*ng g service [name]*/

import { Injectable } from '@angular/core';
import { Pokemon } from '../../../Classes/Pokemon';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  pokemons: Pokemon[] = [
    {
      id: 1,
      name: 'Bulbasaur',
      type: 'Grass/Poison',
      isCool: true
    },
    {
      id: 2,
      name: 'Charmander',
      type: 'Fire',
      isCool: false
    },
    {
      id: 3,
      name: 'Squirtle',
      type: 'Water',
      isCool: true
    },
    {
      id: 4,
      name: 'Pikachu',
      type: 'Electric',
      isCool: true
    },
    {
      id: 5,
      name: 'Eevee',
      type: 'Normal',
      isCool: false
    }]
  constructor() { }

  getPokemon(): Pokemon[] {
    return this.pokemons;
  }
}
