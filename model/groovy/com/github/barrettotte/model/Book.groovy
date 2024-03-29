package com.github.barrettotte.model

import com.github.barrettotte.model.common.Person
import com.github.barrettotte.model.common.Thing

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

import java.math.BigDecimal

@JsonInclude(Include.NON_EMPTY)
class Book extends Thing{
    String[] genres
    long pageLength
    String isbn
    Person author
    BigDecimal price
}
