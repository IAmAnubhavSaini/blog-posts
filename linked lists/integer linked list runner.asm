; Listing generated by Microsoft (R) Optimizing Compiler Version 18.00.30723.0 

include listing.inc

INCLUDELIB LIBCMT
INCLUDELIB OLDNAMES

_DATA	SEGMENT
$SG4459	DB	0aH, 0aH, 'Firing test 1', 0aH, 00H
	ORG $+7
$SG4460	DB	0aH, 0aH, 'Firing test 2', 0aH, 00H
	ORG $+7
$SG4461	DB	0aH, 0aH, 'Firing test 3', 0aH, 00H
	ORG $+7
$SG4462	DB	0aH, 0aH, 'Firing test 4', 0aH, 00H
	ORG $+7
$SG4463	DB	0aH, 0aH, 'Firing test 5', 0aH, 00H
	ORG $+7
$SG4464	DB	0aH, 0aH, 'Firing test 6', 0aH, 00H
_DATA	ENDS
PUBLIC	fire
PUBLIC	main
EXTRN	printf:PROC
EXTRN	TEST_setup1:PROC
EXTRN	TEST_search1:PROC
EXTRN	TEST_delete1:PROC
EXTRN	TEST_delete2:PROC
EXTRN	TEST_circular_list:PROC
pdata	SEGMENT
$pdata$fire DD	imagerel $LN3
	DD	imagerel $LN3+111
	DD	imagerel $unwind$fire
$pdata$main DD	imagerel $LN3
	DD	imagerel $LN3+16
	DD	imagerel $unwind$main
pdata	ENDS
xdata	SEGMENT
$unwind$fire DD	010401H
	DD	04204H
$unwind$main DD	010401H
	DD	04204H
xdata	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
main	PROC
; File c:\src\blog posts\linked lists\integer linked list runner.c
; Line 19
$LN3:
	sub	rsp, 40					; 00000028H
; Line 20
	call	fire
; Line 21
	xor	eax, eax
; Line 22
	add	rsp, 40					; 00000028H
	ret	0
main	ENDP
_TEXT	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
fire	PROC
; File c:\src\blog posts\linked lists\integer linked list runner.c
; Line 3
$LN3:
	sub	rsp, 40					; 00000028H
; Line 4
	lea	rcx, OFFSET FLAT:$SG4459
	call	printf
; Line 5
	call	TEST_setup1
; Line 6
	lea	rcx, OFFSET FLAT:$SG4460
	call	printf
; Line 7
	call	TEST_search1
; Line 8
	lea	rcx, OFFSET FLAT:$SG4461
	call	printf
; Line 9
	call	TEST_delete1
; Line 10
	lea	rcx, OFFSET FLAT:$SG4462
	call	printf
; Line 11
	call	TEST_setup1
; Line 12
	lea	rcx, OFFSET FLAT:$SG4463
	call	printf
; Line 13
	call	TEST_delete2
; Line 14
	lea	rcx, OFFSET FLAT:$SG4464
	call	printf
; Line 15
	call	TEST_circular_list
; Line 17
	add	rsp, 40					; 00000028H
	ret	0
fire	ENDP
_TEXT	ENDS
END
