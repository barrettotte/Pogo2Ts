import { Person } from './common/Person'
import { Thing } from './common/Thing'

export class Book extends Thing{
  genres?: string;
  pageLength?: number;
  isbn?: string;
  author?: Person;
  price?: number;
}
