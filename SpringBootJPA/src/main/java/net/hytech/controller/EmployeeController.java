package net.hytech.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import net.hytech.respository.EmployeeRespository;
import net.hytech.model.*;


@CrossOrigin("*")
@RestController
@RequestMapping("/api")
public class EmployeeController {

	@Autowired
	private EmployeeRespository employeeRepository;
	
	@GetMapping
	public List<Employee> getAllEmployee()
	{
		return employeeRepository.findAll();
	}
	
}
