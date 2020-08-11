package com.github.barrettotte.groovy.model.common

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

@JsonInclude(Include.NON_EMPTY)
class Address {
    String line1
    String line2
    String city
    String state
    String zip
}
