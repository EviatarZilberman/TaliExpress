import { Component, Input, OnInit } from '@angular/core';
import { Pokemon } from '../../../../Classes/Pokemon';


@Component({
  selector: 'app-pokemon-detail',
  standalone: false,
  templateUrl: './pokemon-detail.component.html',
  styleUrl: './pokemon-detail.component.css'
})
export class PokemonDetailComponent implements OnInit {
  @Input()
  detail!: Pokemon;

  constructor() { }

  ngOnInit(): void {
  }

}
