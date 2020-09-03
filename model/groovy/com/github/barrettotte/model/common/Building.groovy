package com.github.barrettotte.model.common

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

@JsonInclude(Include.NON_EMPTY)
class Building extends Thing{
    Person owner
    Address address
}
