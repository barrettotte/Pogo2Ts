package com.github.barrettotte.model

import com.github.barrettotte.model.common.Person
import com.github.barrettotte.model.common.Thing

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

import java.math.BigDecimal

@JsonInclude(Include.NON_EMPTY)
class TestObj extends Thing{
    String[] myArray
    List<String> myList
    byte myByte
    int myInt = 8
    long myLong
    float myFloat
    double myDouble
    String myString
    Person myObject
    BigDecimal myBigDecimal
}
