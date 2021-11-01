package net.hytech.respository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import net.hytech.model.Employee;


public interface EmployeeRespository  extends JpaRepository<Employee, Long>{
	
}
