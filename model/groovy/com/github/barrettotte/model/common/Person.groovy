package com.github.barrettotte.model.common

import com.meme.test.Hello
import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

@JsonInclude(Include.NON_EMPTY)
class Person extends Thing{
    String firstName
    String lastName
    Integer age
}
