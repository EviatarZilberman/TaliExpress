import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Pokemon } from '../../../../Classes/Pokemon';


@Component({
  selector: 'app-pokemon-detail',
  standalone: false,
  templateUrl: './pokemon-detail.component.html',
  styleUrl: './pokemon-detail.component.css'
})
export class PokemonDetailComponent implements OnInit {
  @Input() // passes data to this component.
  detail!: Pokemon;

  @Output()
  remove: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }

  onRemove() {
    this.remove.emit(this.detail); // Launch the output up.
  }

}
