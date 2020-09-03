package com.github.barrettotte.model

import com.github.barrettotte.model.common.Building
import com.github.barrettotte.model.common.Person

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

import java.util.List
import java.util.ArrayList

@JsonInclude(Include.NON_EMPTY)
class Library extends Building{
    List<Book> books = new ArrayList<Book>()
    List<Person> members = new ArrayList<Person>()
}
