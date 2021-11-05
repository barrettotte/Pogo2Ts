package com.github.barrettotte.model

import javax.persistence.CascadeType
import javax.persistence.Entity
import javax.persistence.ManyToMany
import javax.persistence.OneToMany

import com.fasterxml.jackson.annotation.JsonInclude
import com.fasterxml.jackson.annotation.JsonInclude.Include

import com.github.barrettotte.model.common.Address
import com.github.barrettotte.model.common.Person

@Entity
@JsonInclude(Include.NON_EMPTY)
class Account extends Person {

    // just testing field-level annotations

    String accountNumber
    String accountType
    String accountName

	@ManyToMany(cascade = CascadeType.ALL)
    List<String> roles = []

    @OneToMany(orphanRemoval = true, cascade = CascadeType.ALL)
    List<Address> addresses = []
}
