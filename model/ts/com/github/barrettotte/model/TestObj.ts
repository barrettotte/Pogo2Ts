import { Person } from './common/Person'
import { Thing } from './common/Thing'

export class TestObj extends Thing{
  myArray?: string;
  myList?: string[];
  myByte?: number;
  myInt?: number;
  myLong?: number;
  myFloat?: number;
  myDouble?: number;
  myString?: string;
  myObject?: Person;
  myBigDecimal?: number;
}
