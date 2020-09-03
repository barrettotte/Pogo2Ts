import { Building } from './common/Building'
import { Person } from './common/Person'
import { Book } from './Book'

export class Library extends Building{
  books?: Book[];
  members?: Person[];
}
