package com.github.barrettotte.groovy.model.common

import com.meme.test.Hello
import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

@JsonInclude(Include.NON_EMPTY)
class Person {
    String firstName
    String lastName
    Integer age
}
