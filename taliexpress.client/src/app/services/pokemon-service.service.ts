/*ng g service [name]*/

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pokemon } from '../../../Classes/Pokemon';
import { Observable } from 'rxjs';

const POKEMON_API_URL : string = 'http://localhost:5000/PokemonTest/getPokemonServer';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  //pokemons: Pokemon[] = [
  //  {
  //    id: 1,
  //    name: 'Bulbasaur',
  //    type: 'Grass/Poison',
  //    isCool: true
  //  },
  //  {
  //    id: 2,
  //    name: 'Charmander',
  //    type: 'Fire',
  //    isCool: false
  //  },
  //  {
  //    id: 3,
  //    name: 'Squirtle',
  //    type: 'Water',
  //    isCool: true
  //  },
  //  {
  //    id: 4,
  //    name: 'Pikachu',
  //    type: 'Electric',
  //    isCool: true
  //  },
  //  {
  //    id: 5,
  //    name: 'Eevee',
  //    type: 'Normal',
  //    isCool: false
  //  }]
  constructor(private http: HttpClient) { }

  getPokemon(): Observable<Pokemon[]> {
    return this.http.get<Pokemon[]>(POKEMON_API_URL);
  }
}
