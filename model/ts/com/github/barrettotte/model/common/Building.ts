import { Thing } from './Thing'
import { Person } from './Person'
import { Address } from './Address'

export class Building extends Thing{
  owner?: Person;
  address?: Address;
}
